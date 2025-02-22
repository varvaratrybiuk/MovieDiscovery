import { useQuery } from "@tanstack/react-query";

import AddFilmForm from "../../components/addFilmForm/AddFilmForm";

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

    try {
      await addMovie(movieData);
      console.log("Movie added successfully!");
    } catch (error) {
      throw error;
    }
  };
  
  if (isLoading) return <p>Завантаження жанрів...</p>;
  if (error) return <p>Помилка: {error.message}</p>;

  return (
    <>
      <AddFilmForm genres={genres} onSubmit={onSubmit} />
    </>
  );
}
