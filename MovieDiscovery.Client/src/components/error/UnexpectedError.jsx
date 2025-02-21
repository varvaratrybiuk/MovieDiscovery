import { useNavigate } from "react-router";


import style from "./ErrorStyle.module.css";
import buttonStyles from "../../styles/buttonsStyle.module.css";

export default function UnexpectedError(props) {
  const { errorText } = props;
  const navigate = useNavigate();

  return (
    <div className={style["errorContainer"]}>
      Сталася помилка: {errorText}
      <div className={style["errorButtons-container"]}>
        <button
          className={buttonStyles["pink-button"]}
        >
          Спробувати ще раз
        </button>
        <button
          onClick={() => {
            navigate("/");
          }}
          className={buttonStyles["pink-button"]}
        >
          Повернутися до Головної сторінки
        </button>
      </div>
    </div>
  );
}
