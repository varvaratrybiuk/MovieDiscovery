import { useState, lazy } from "react";
import { useQuery } from "@tanstack/react-query";

const FilmCard = lazy(() => import("../../components/filmCard/FilmCard.jsx"));
const ErrorMessage = lazy(() =>
  import("../../components/errorMessage/ErrorMessage")
);

import { getRandom, getByName } from "../../services/movieService.js";

import buttonStyles from "../../styles/buttonsStyle.module.css";
import style from "./HomeStyle.module.css";

export default function Home() {
  const [searchTitle, setSearchTitle] = useState("");

  const {
    data: searchMovieData,
    isLoading: isLoadingSearch,
    error: errorSearch,
    refetch: refetchSearch,
  } = useQuery({
    queryKey: ["searchMovie", searchTitle],
    queryFn: async () => getByName(searchTitle),
    enabled: false,
  });

  const {
    data: randomMovieData,
    isLoading: isLoadingRandom,
    error: errorRandom,
    refetch: refetchRandom,
  } = useQuery({
    queryKey: ["randomMovie"],
    queryFn: getRandom,
    enabled: false,
  });

  const movieData = searchMovieData || randomMovieData;
  const isLoading = isLoadingSearch || isLoadingRandom;
  const errorMessage =
    errorSearch?.response.data.message || errorRandom?.response.data.message;

  const handleSearchClick = () => {
    if (searchTitle) {
      refetchSearch();
    }
  };

  const handleRandomMovieClick = () => {
    refetchRandom();
  };

  return (
    <div className={style["container"]}>
      <div className={style["input-container"]}>
        <input
          placeholder="Введіть назву фільму"
          value={searchTitle}
          onChange={(e) => setSearchTitle(e.target.value)}
          required
        />
        <button
          className={buttonStyles["pink-button"]}
          type="submit"
          onClick={handleSearchClick}
        >
          Знайти
        </button>
      </div>
      <button
        className={buttonStyles["pink-button"]}
        type="button"
        onClick={handleRandomMovieClick}
      >
        Знайти випадковий фільм
      </button>

      <ErrorMessage error={errorMessage} />
      {isLoading && <p>Завантаження...</p>}

      {movieData && (
        <FilmCard
          title={movieData.title}
          description={movieData.description}
          year={movieData.year}
          rating={movieData.rating}
          genres={movieData.genres}
        />
      )}
    </div>
  );
}
