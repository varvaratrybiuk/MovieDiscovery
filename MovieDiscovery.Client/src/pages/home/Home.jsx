import buttonStyles from "../../styles/buttonsStyle.module.css";
import style from "./HomeStyle.module.css";

export default function Home() {
  return (
    <>
      <div className={style["input-container"]}>
        <input placeholder="Введіть назву фільму" required />
        <button className={buttonStyles["pink-button"]} type="submit">
          Знайти
        </button>
      </div>
      <button className={buttonStyles["pink-button"]} type="submit">
        Знайти випадковий фільм
      </button>
     
    </>
  );
}
