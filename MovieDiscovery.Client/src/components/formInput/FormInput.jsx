import { useFormContext } from "react-hook-form";

import ErrorMessage from "../errorMessage/ErrorMessage";

import style from "./FormInputStyle.module.css";

export default function FormInput(props) {
  const {
    fieldKey,
    title,
    placeholderText,
    requiredText,
    validationOptions,
    type = "text",
  } = props;
  
  const {
    register,
    formState: { errors },
  } = useFormContext();

  return (
    <div className={style["input-container"]}>
      <label htmlFor={fieldKey}>{title}</label>
      <input
        type={type}
        id={fieldKey}
        {...register(fieldKey, {
          required: requiredText ? requiredText : false,
          ...validationOptions,
        })}
        placeholder={placeholderText}
      />
      <ErrorMessage error={errors[fieldKey]?.message} />
    </div>
  );
}
