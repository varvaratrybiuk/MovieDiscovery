import * as yup from "yup";

export const movieValidationShema = yup.object().shape({
  filmTitle: yup.string().required("Назва фільму є обов'язковою"),
  description: yup.string().required("Опис є обов'язковим"),
  filmGenres: yup
    .array()
    .test("at-least-one-selected", "Оберіть хоча б один жанр", (value) =>
      value?.some((v) => v === true)
    ),
  year: yup
    .number()
    .typeError("Рік виходу має бути числом")
    .required("Рік виходу є обов'язковим")
    .integer("Рік має бути цілим числом")
    .min(1920, "Рік має бути не раніше 1920")
    .max(new Date().getFullYear(), "Рік не може бути у майбутньому"),
  rating: yup
    .number()
    .typeError("Рейтинг має бути числом")
    .required("Рейтинг фільму є обов'язковим")
    .min(0, "Рейтинг має бути більше 0")
    .max(10, "Рейтинг не може бути більше 10"),
});
