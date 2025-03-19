import api from "./api";

export const getMovies = async () => {
  try {
    const response = await api.get("/movies");
    return response.data;
  } catch (error) {
    // console.error("Помилка отримання фільмів:", error);
    throw error;
  }
};

export const getByName = async (title) => {
  try {
    const response = await api.get(`/movies/${title}`);
    return response.data;
  } catch (error) {
    // console.error("Помилка отримання фільмів:", error);
    throw error;
  }
};

export const getRandom = async () => {
  try {
    const response = await api.get(`/movies/random`);
    return response.data;
  } catch (error) {
    // console.error("Помилка отримання фільмів:", error);
    throw error;
  }
};

export const addMovie = async (movieData) => {
  try {
    const response = await api.post("/movies/add", movieData, {
      withCredentials: true,
    });
    return response.data;
  } catch (error) {
    //console.error("Помилка додавання фільму:", error);
    throw error;
  }
};
