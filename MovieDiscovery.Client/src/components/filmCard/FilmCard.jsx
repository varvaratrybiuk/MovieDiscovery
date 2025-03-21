import PropTypes from "prop-types";

import style from "./FilmCardStyle.module.css";

/**
 * Компонент для виведення інформації про фільм
 */
export default function FilmCard({
  title,
  description = "Опис до фільму відсутній",
  year,
  rating = 0.0,
  genres,
}) {
  return (
    <div className={style["card"]}>
      <p>{title}</p>
      <div className={style["description"]}>
        <div className={style["title"]}>Опис фільму</div>
        <div>
          <div className={style["genre"]}>Жанри: {genres.join(", ")}</div>
          <div>{description}</div>
        </div>
      </div>

      <div className={style["row"]}>
        <div>Рейтинг: {rating}</div>
        <div>Рік виходу: {year}</div>
      </div>
    </div>
  );
}

FilmCard.propTypes = {
  /** Назва фільму */
  title: PropTypes.string.isRequired,

  /** Опис фільму */
  description: PropTypes.string,

  /** Рік випуску */
  year: PropTypes.number.isRequired,

  /** Рейтинг фільму */
  rating: PropTypes.number,

  /** Жанри фільму */
  genres: PropTypes.arrayOf(PropTypes.string).isRequired,
};
