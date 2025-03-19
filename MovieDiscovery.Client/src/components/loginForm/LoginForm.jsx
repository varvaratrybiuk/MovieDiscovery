import { useForm, FormProvider } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";

import FormInput from "../formInput/FormInput";

import { loginValidationSchema } from "../../schemas/loginFormValidationSchema";

import buttonStyles from "../../styles/buttonsStyle.module.css";
import style from "./LoginFormStyle.module.css";

export default function LoginForm(props) {
  const { onSubmit } = props;
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(loginValidationSchema),
  });

  return (
    <FormProvider {...{ register, formState: { errors } }}>
      <form
        className={style["form-style"]}
        onSubmit={handleSubmit((data) => onSubmit(data))}
      >
        <FormInput
          fieldKey="username"
          title="Ім'я користувача"
          placeholderText="Введіть ім'я"
        />

        <FormInput
          fieldKey="password"
          title="Пароль"
          placeholderText="Введіть пароль"
          type="password"
        />

        <button className={buttonStyles["pink-button"]} type="submit">
          Увійти
        </button>
      </form>
    </FormProvider>
  );
}
