import api from "./api";

export const getGenres = async () => {
  try {
    const response = await api.get("/genres");
    return response.data;
  } catch (error) {
    //console.error("Помилка отримання жанрів:", error);
    throw error;
  }
};

