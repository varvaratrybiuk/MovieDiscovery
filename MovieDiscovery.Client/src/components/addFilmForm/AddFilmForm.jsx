import { useForm, FormProvider } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";

import FormInput from "../formInput/FormInput";
import FormTextarea from "../formTextarea/FormTextarea";
import GenreOptions from "../genreOptions/GenreOptions";

import { movieValidationShema } from "../../schemas/movieFormValidationSchema";

import buttonStyles from "../../styles/buttonsStyle.module.css";
import style from "./AddFilmFormStyle.module.css";

export default function AddFilmForm(props) {
  const { genres, onSubmit } = props;
  const {
    register,
    handleSubmit,
    control,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(movieValidationShema),
  });

  return (
    <FormProvider {...{ register, control, formState: { errors } }}>
      <form
        className={style["form-style"]}
        onSubmit={handleSubmit((data) => onSubmit(data))}
      >
        <FormInput
          fieldKey="filmTitle"
          title="Назва фільму"
          placeholderText="Введіть назву"
        />

        <FormTextarea
          fieldKey="description"
          title="Опис фільму"
          placeholderText="Додайте опис"
        />

        <div>
          <GenreOptions
            description="Жанр фільму:"
            options={genres}
            fieldname="filmGenres"
          />
          {errors.filmGenres && (
            <div>
              <span
                style={{
                  color: "#ff4c4c",
                  fontSize: "12px",
                  marginTop: "5px",
                }}
              >
                {errors.filmGenres.root.message}
              </span>
            </div>
          )}
        </div>

        <FormInput
          fieldKey="year"
          title="Рік виходу"
          placeholderText="Введіть рік"
        />

        <FormInput
          fieldKey="rating"
          title="Рейтинг фільму"
          placeholderText="Введіть рейтинг"
        />
        <button className={buttonStyles["pink-button"]} type="submit">
          Додати новий фільм
        </button>
      </form>
    </FormProvider>
  );
}
