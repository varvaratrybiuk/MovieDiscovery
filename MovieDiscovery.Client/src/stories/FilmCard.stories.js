import FilmCard from "../components/filmCard/FilmCard.jsx";

export default {
  title: "Components/FilmCard",
  component: FilmCard,
  tags: ["autodocs"],
  parameters: {
    layout: "centered",
  },
  argTypes: {
    genres: {
      control: {
        type: "multi-select",
      },
      options: ["Фентезі", "Музичні", "Комедія", "Мелодрами"],
    },
    rating: {
      control: {
        type: "number",
        min: 0,
        max: 10,
      },
    },
    year: {
      control: {
        type: "number",
        min: 1920,
        max: 2025,
      },
    },
  },
};

export const FilmInfo = {
  args: {
    title: "Ла Ла Ленд",
    description:
      "Нова кінострічка режисера Дем'єна Шазелла - це мюзикл, мелодрама, комедія і історія любові в одній кінострічці. Лос-Анджелес (Ла-Ла Ленд) - дивовижне місце, фабрика мрій і рай на землі в очах багатьох молодих людей. Саме тут двом головним героям кінокартини судилося зустрітися, знайти і втратити своє щастя. ",
    year: 2016,
    rating: 8,
    genres: ["Комедія", "Мелодрами", "Музичні"],
  },
};

export const FilmInfoWithoutDescription = {
  args: {
    title: "Ла Ла Ленд",
    year: 2016,
    rating: 8,
    genres: ["Комедія", "Мелодрами", "Музичні"],
  },
};

export const FilmInfoWithoutRating = {
  args: {
    title: "Ла Ла Ленд",
    description:
      "Нова кінострічка режисера Дем'єна Шазелла - це мюзикл, мелодрама, комедія і історія любові в одній кінострічці. Лос-Анджелес (Ла-Ла Ленд) - дивовижне місце, фабрика мрій і рай на землі в очах багатьох молодих людей. Саме тут двом головним героям кінокартини судилося зустрітися, знайти і втратити своє щастя. ",
    year: 2016,
    genres: ["Комедія", "Мелодрами", "Музичні"],
  },
};
