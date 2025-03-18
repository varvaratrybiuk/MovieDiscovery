import { useNavigate } from "react-router";
import { lazy } from "react";

import RegisterForm from "../../components/registerForm/RegisterForm";
const ErrorMessage = lazy(() =>
  import("../../components/errorMessage/ErrorMessage")
);

import { AccountMachineContext } from "../../contexts/accountContext";

export default function RegisterPage() {
  let navigate = useNavigate();
  const actor = AccountMachineContext.useActorRef();
  const error = AccountMachineContext.useSelector(
    (state) => state.context.errorMessage
  );

  const onSubmit = async (data) => {
    actor.send({
      type: "REGISTER",
      user: data,
    });
    navigate("/login");
  };

  return (
    <>
      <ErrorMessage error={error} />
      <RegisterForm onSubmit={onSubmit} />
    </>
  );
}
