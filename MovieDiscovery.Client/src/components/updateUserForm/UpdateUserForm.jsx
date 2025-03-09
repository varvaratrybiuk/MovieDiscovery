import { useForm, FormProvider } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";

import FormInput from "../formInput/FormInput";

import { updateUserValidationSchema } from "../../schemas/updateUserFormValidationSchema";

import buttonStyles from "../../styles/buttonsStyle.module.css";
import style from "./UpdateUserFormStyle.module.css";

export default function UpdateUserForm(props) {
  const { onSubmit } = props;
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(updateUserValidationSchema),
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
          fieldKey="email"
          title="Електронна пошта"
          placeholderText="Введіть електронну пошту"
        />

        <FormInput
          fieldKey="password"
          title="Пароль"
          placeholderText="Введіть пароль"
          type="password"
        />

        <button className={buttonStyles["pink-button"]} type="submit">
          Оновити
        </button>
      </form>
    </FormProvider>
  );
}
