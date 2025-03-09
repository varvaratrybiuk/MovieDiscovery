import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router";
import { lazy } from "react";

import LoginForm from "../../components/loginForm/LoginForm";
const ErrorMessage = lazy(() =>
  import("../../components/errorMessage/ErrorMessage")
);

import { login } from "../../services/accountService";

export default function LoginPage() {
  let navigate = useNavigate();
  const mutation = useMutation({
    mutationFn: login,
    onSuccess: (data) => {
      console.log(data);
      navigate("/");
    },
  });

  const onSubmit = async (data) => {
    mutation.mutate({
      username: data.username,
      password: data.password,
    });
  };

  return (
    <>
      <ErrorMessage error={mutation.error?.response?.data?.message} />
      <LoginForm onSubmit={onSubmit} />
    </>
  );
}
