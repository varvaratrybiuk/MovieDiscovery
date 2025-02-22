import style from "./FilmCardStyle.module.css";

export default function FilmCard(props) {
  const { title, description, year, rating, genres } = props;
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
