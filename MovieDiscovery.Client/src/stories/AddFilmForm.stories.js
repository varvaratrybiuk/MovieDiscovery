import { fn, userEvent, within } from "@storybook/test";

import AddFilmForm from "../components/addFilmForm/AddFilmForm.jsx";

export default {
  title: "Components/AddFilm",
  component: AddFilmForm,
  tags: ["autodocs"],
  parameters: {
    layout: "centered",
  },
  args: {
    genres: [
      {
        id: 1,
        name: "Фентезі",
      },
      {
        id: 2,
        name: "Музичні",
      },
      {
        id: 7,
        name: "Комедія",
      },
      {
        id: 3,
        name: "Мелодрами",
      },
    ],
    onSubmit: fn(),
  },
  argTypes: {
    genres: {
      control: {
        type: "multi-select",
      },
      options: ["Фентезі", "Музичні", "Комедія", "Мелодрами"],
      mapping: {
        Фентезі: { id: 1, name: "Фентезі" },
        Музичні: { id: 2, name: "Музичні" },
        Комедія: { id: 7, name: "Комедія" },
        Мелодрами: { id: 3, name: "Мелодрами" },
      },
    },
  },
};

export const FilledForm = {
  play: async ({ canvasElement }) => {
    const canvas = within(canvasElement);

    await userEvent.type(
      canvas.getByPlaceholderText("Введіть назву"),
      "Ла Ла Ленд"
    );
    await userEvent.type(canvas.getByPlaceholderText("Введіть рік"), "2016");
    await userEvent.type(canvas.getByPlaceholderText("Введіть рейтинг"), "8");
    await userEvent.click(canvas.getByLabelText("Музичні"));
    await userEvent.click(canvas.getByLabelText("Комедія"));
    await userEvent.click(canvas.getByLabelText("Мелодрами"));
    await userEvent.type(
      canvas.getByPlaceholderText("Додайте опис"),
      "Нова кінострічка режисера Дем'єна Шазелла - це мюзикл, мелодрама, комедія і історія любові в одній кінострічці. Лос-Анджелес (Ла-Ла Ленд) - дивовижне місце, фабрика мрій і рай на землі в очах багатьох молодих людей. Саме тут двом головним героям кінокартини судилося зустрітися, знайти і втратити своє щастя. "
    );
  },
};

export const FormWithValidationErrors = {
  play: async ({ canvasElement }) => {
    const canvas = within(canvasElement);
    const input = canvas.getByPlaceholderText("Введіть рейтинг");
    await userEvent.type(input, "-10");
    const submitButton = canvas.getByRole("button", {
      name: /Додати новий фільм/i,
    });
    await userEvent.click(submitButton);
  },
};
