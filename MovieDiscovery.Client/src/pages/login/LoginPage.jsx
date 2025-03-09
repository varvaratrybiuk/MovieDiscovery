import { lazy } from "react";
import { useNavigate } from "react-router";

import LoginForm from "../../components/loginForm/LoginForm";
const ErrorMessage = lazy(() =>
  import("../../components/errorMessage/ErrorMessage")
);

import { AccountMachineContext } from "../../contexts/accountContext";

export default function LoginPage() {
  const actor = AccountMachineContext.useActorRef();
  const error = AccountMachineContext.useSelector(
    (state) => state.context.errorMessage
  );

  const onSubmit = async (data) => {
    actor.send({
      type: "LOGIN",
      username: data.username,
      password: data.password,
    });
  };

  return (
    <>
      <ErrorMessage error={error} />
      <LoginForm onSubmit={onSubmit} />
    </>
  );
}
