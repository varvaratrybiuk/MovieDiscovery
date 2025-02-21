import { useFormContext } from "react-hook-form";

import OptionItem from "../optionItem/OptionItem.jsx";

import style from "./GenreOptionsStyle.module.css";

export default function GenreOptions(props) {
  const { description, options, fieldname } = props;


  return (
    <div className={style["option-group"]}>
      <label className={style["description"]}>{description}</label>
      <div className={style["checkbox-list"]}>
        {options.map((option) => {
          const currentKey = `${fieldname}.${option.id}`;
          return (
            <div key={currentKey}>
              <OptionItem name={`${currentKey}`} value={option.name} />
            </div>
          );
        })}
      </div>


    </div>
  );
}
