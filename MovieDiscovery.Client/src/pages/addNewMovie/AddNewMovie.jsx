import { useQuery } from "@tanstack/react-query";

import AddFilmForm from "../../components/addFilmForm/AddFilmForm";

import { getGenres } from "../../services/genreService";

export default function AddNewMovie() {
  const {
    data: genres = [],
    isLoading,
    error,
  } = useQuery({
    queryKey: ["genres"],
    queryFn: getGenres,
  });
  const onSubmit = (data) => {
    console.log(data);
  };
  if (isLoading) return <p>Завантаження жанрів...</p>;
  if (error) return <p>Помилка: {error.message}</p>;

  return (
    <>
      <AddFilmForm genres={genres} onSubmit={onSubmit} />
    </>
  );
}
