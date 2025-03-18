import { useState, lazy, useEffect } from "react";
import { useQuery } from "@tanstack/react-query";
import Cookies from "js-cookie";

const FilmCard = lazy(() => import("../../components/filmCard/FilmCard.jsx"));
const ErrorMessage = lazy(() =>
  import("../../components/errorMessage/ErrorMessage")
);

import { useLastMovie } from "../../hooks/useLastMovie.js";
import { getRandom, getByName } from "../../services/movieService.js";

import buttonStyles from "../../styles/buttonsStyle.module.css";
import style from "./HomeStyle.module.css";

export default function Home() {
  const [searchTitle, setSearchTitle] = useState("");

  useEffect(() => {
    const lastMovieCookie = Cookies.get("last-movie");

    if (lastMovieCookie) {
      setSearchTitle(JSON.parse(lastMovieCookie).title);
    }
  }, []);

  const {
    data: searchMovieData,
    isLoading: isLoadingSearch,
    error: errorSearch,
  } = useQuery({
    queryKey: ["searchMovie", searchTitle],
    queryFn: async () => getByName(searchTitle),
    enabled: !!searchTitle,
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

  useLastMovie(randomMovieData?.title || searchTitle);

  const movieData = randomMovieData || searchMovieData;

  const isLoading = isLoadingSearch || isLoadingRandom;
  const errorMessage =
    errorSearch?.response.data.message || errorRandom?.response.data.message;

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

      {movieData &&
        (Array.isArray(movieData) ? (
          <div className={style["movies-container"]}>
            {movieData.map((movie, index) => (
              <FilmCard
                key={index}
                title={movie.title}
                description={movie.description}
                year={movie.year}
                rating={movie.rating}
                genres={movie.genres}
              />
            ))}
          </div>
        ) : (
          <FilmCard
            title={movieData.title}
            description={movieData.description}
            year={movieData.year}
            rating={movieData.rating}
            genres={movieData.genres}
          />
        ))}
    </div>
  );
}
