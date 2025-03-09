import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router";
import { lazy } from "react";

import RegisterForm from "../../components/registerForm/RegisterForm";
const ErrorMessage = lazy(() =>
  import("../../components/errorMessage/ErrorMessage")
);

import { register } from "../../services/accountService";

export default function RegisterPage() {
  let navigate = useNavigate();
  const mutation = useMutation({
    mutationFn: register,
    onSuccess: (data) => {
      console.log(data.message);
      navigate("/login");
    },
  });

  const onSubmit = async (data) => {
    mutation.mutate({
      username: data.username,
      email: data.email,
      password: data.password,
    });
  };

  return (
    <>
      <ErrorMessage error={mutation.error?.response?.data?.message} />
      <RegisterForm onSubmit={onSubmit} />
    </>
  );
}
