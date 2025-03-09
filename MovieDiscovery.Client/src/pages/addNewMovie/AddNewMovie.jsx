import { useMutation, useQuery } from "@tanstack/react-query";
import { lazy, useState } from "react";

import AddFilmForm from "../../components/addFilmForm/AddFilmForm";
const ErrorMessage = lazy(() =>
  import("../../components/errorMessage/ErrorMessage")
);

import { getGenres } from "../../services/genreService";
import { addMovie } from "../../services/movieService";
import { filterOutFalse } from "../../helpers/filterData";

export default function AddNewMovie() {
  const [infoMessage, setInfoMessage] = useState("");
  const {
    data: genres = [],
    isLoading,
    error,
  } = useQuery({
    queryKey: ["genres"],
    queryFn: getGenres,
  });

  const mutation = useMutation({
    mutationFn: addMovie,
    onSuccess: () => {
      setInfoMessage("Фільм додано успішно");
    },
  });

  const onSubmit = async (data) => {
    console.log(data);
    const movieData = {
      title: data.filmTitle,
      description: data.description,
      genresID: filterOutFalse(data.filmGenres),
      year: data.year,
      rating: data.rating,
    };
    console.log(movieData);
    mutation.mutate(movieData);
  };

  if (isLoading) return <p>Завантаження жанрів...</p>;
  if (error) return <ErrorMessage error={error.response.data.message} />;

  return (
    <>
      {infoMessage && <p>{infoMessage}</p>}
      <ErrorMessage error={mutation.error?.response.data.message} />
      <AddFilmForm genres={genres} onSubmit={onSubmit} />
    </>
  );
}
