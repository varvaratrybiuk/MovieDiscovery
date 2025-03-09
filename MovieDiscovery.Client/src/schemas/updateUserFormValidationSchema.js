import * as yup from "yup";

export const updateUserValidationSchema = yup.object().shape(
  {
    username: yup
      .string()
      .nullable()
      .notRequired()
      .when("username", {
        is: (value) => value && value.length > 0,
        then: (rule) =>
          rule
            .min(3, "Ім'я користувача має містити щонайменше 3 символи")
            .max(20, "Ім'я користувача не може бути довшим за 20 символів"),
      }),

    email: yup
      .string()
      .nullable()
      .notRequired()
      .email("Введіть коректну електронну пошту"),

    password: yup
      .string()
      .nullable()
      .notRequired()
      .when("password", {
        is: (value) => value && value.length > 0,
        then: (rule) =>
          rule
            .min(8, "Пароль має містити щонайменше 8 символів")
            .max(50, "Пароль не може бути довшим за 50 символів"),
      }),
  },
  [
    ["password", "password"],
    ["username", "username"],
  ]
);
