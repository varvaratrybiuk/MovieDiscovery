import style from "./ErrorMessageStyle.module.css";

export default function ErrorMessage(props) {
  const { error } = props;
  return <>{error && <div className={style["error-message"]}>{error}</div>}</>;
}
