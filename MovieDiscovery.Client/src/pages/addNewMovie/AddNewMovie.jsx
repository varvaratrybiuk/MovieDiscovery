import { useMutation, useQuery } from "@tanstack/react-query";
import { lazy } from "react";

import AddFilmForm from "../../components/addFilmForm/AddFilmForm";
const ErrorMessage = lazy(() =>
  import("../../components/errorMessage/ErrorMessage")
);

import { getGenres } from "../../services/genreService";
import { addMovie } from "../../services/movieService";
import { filterOutFalse } from "../../helpers/filterData";

export default function AddNewMovie() {
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
      console.log("Фільм додано успішно");
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
      <ErrorMessage error={mutation.error?.response.data.message} />
      <AddFilmForm genres={genres} onSubmit={onSubmit} />
    </>
  );
}
