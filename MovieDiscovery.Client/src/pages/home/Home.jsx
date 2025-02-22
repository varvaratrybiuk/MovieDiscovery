import { useState } from "react";

import FilmCard from "../../components/filmCard/FilmCard.jsx";

import { getRandom, getByName } from "../../services/movieService.js";

import buttonStyles from "../../styles/buttonsStyle.module.css";
import style from "./HomeStyle.module.css";

export default function Home() {
  const [movieData, setMovieData] = useState(null);
  const [error, setError] = useState(null);

  const handleSearchClick = async () => {
    const title = document.querySelector("input").value;
    try {
      const data = await getByName(title);
      setMovieData(data);
      setError("");
    } catch (error) {
      setError("Помилка отримання фільмів");
    }
  };

  const handleRandomMovieClick = async () => {
    try {
      const data = await getRandom();
      setMovieData(data);
      setError("");
    } catch (error) {
      setError("Помилка отримання фільмів");
      console.log(error);
    }
  };

  return (
    <>
      <div className={style["container"]}>
        <div className={style["input-container"]}>
          <input placeholder="Введіть назву фільму" required />
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

        {error && <div className={style["error-message"]}>{error}</div>}

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
    </>
  );
}
