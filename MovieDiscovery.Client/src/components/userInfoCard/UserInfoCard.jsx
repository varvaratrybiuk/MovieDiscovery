import styles from "./UserInfoCardStyle.module.css";

export default function UserInfoCard(props) {
  const { user } = props;
  return (
    <div className={styles["card"]}>
      <div className={styles["userInfo"]}>
        <h2>Ім'я користувача: {user.username}</h2>
        <p>Електронна пошта: {user.email}</p>
      </div>
    </div>
  );
}
