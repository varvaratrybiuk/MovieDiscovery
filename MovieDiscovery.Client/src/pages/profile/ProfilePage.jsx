import { lazy } from "react";

import UpdateUserForm from "../../components/updateUserForm/UpdateUserForm";
import UserInfoCard from "../../components/userInfoCard/UserInfoCard";
const ErrorMessage = lazy(() =>
  import("../../components/errorMessage/ErrorMessage")
);

import { AccountMachineContext } from "../../contexts/accountContext";

import style from "./ProfilePageStyle.module.css";
import buttonStyles from "../../styles/buttonsStyle.module.css";

export default function ProfilePage() {
  const actor = AccountMachineContext.useActorRef();
  const error = AccountMachineContext.useSelector(
    (state) => state.context.errorMessage
  );
  const userInfo = AccountMachineContext.useSelector(
    (state) => state.context.user
  );

  // const { data, isLoading, refetch } = useQuery({
  //   queryKey: ["userInfo"],
  //   queryFn: getAuthUserInfo,
  // });

  const handleUpdateClick = (userData) => {
    actor.send({
      type: "UPDATE_PROFILE",
      profileData: userData,
    });
    //refetch();
  };

  const handleDeleteClick = () => {
    actor.send({
      type: "DELETE_ACCOUNT",
    });
  };

  const handleLogoutClick = () => {
    actor.send({
      type: "LOGOUT",
    });
  };

  //if (isLoading) return <p>Завантаження...</p>;

  return (
    <div className={style["menu-container"]}>
      <ul className={style["options-container"]}>
        <li className={buttonStyles["pink-button"]} onClick={handleDeleteClick}>
          Видалити профіль
        </li>
        <li className={buttonStyles["pink-button"]} onClick={handleLogoutClick}>
          Вийти
        </li>
      </ul>
      <div className={style["update-container"]}>
        <div>
          <ErrorMessage error={error} />
          <UpdateUserForm onSubmit={handleUpdateClick} />
        </div>
        <div>
          {userInfo ? (
            <UserInfoCard user={userInfo} />
          ) : (
            <p>Користувача не знайдено</p>
          )}
        </div>
      </div>
    </div>
  );
}
