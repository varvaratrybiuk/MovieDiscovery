import * as yup from "yup";

export const registerValidationSchema = yup.object().shape({
  username: yup
    .string()
    .required("Ім'я користувача є обов'язковим")
    .min(3, "Ім'я користувача має містити щонайменше 3 символи")
    .max(20, "Ім'я користувача не може бути довшим за 20 символів"),

  email: yup
    .string()
    .required("Електронна пошта є обов'язковою")
    .email("Введіть коректну електронну пошту"),

  password: yup
    .string()
    .required("Пароль є обов'язковим")
    .min(8, "Пароль має містити щонайменше 8 символів")
    .max(50, "Пароль не може бути довшим за 50 символів"),
});