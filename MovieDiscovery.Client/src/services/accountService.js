import api from "./api";

export const login = async (loginData) => {
  try {
    const response = await api.post("/account/login", loginData, {
      withCredentials: true,
    });
    return response.data;
  } catch (error) {
    console.error("Помилка при вході користувача:", error);
    throw error;
  }
};

export const register = async (registerData) => {
  try {
    const response = await api.post("/account/register", registerData);
    return response.data;
  } catch (error) {
    console.error("Помилка при додаванні користувача:", error);
    throw error;
  }
};

export const logout = async () => {
  try {
    const response = await api.post("/account/logout");
    return response.data;
  } catch (error) {
    console.error("Помилка при виході:", error);
    throw error;
  }
};

export const checkAuth = async () => {
  try {
    const response = await api.get("/account/check-auth", {
      withCredentials: true,
    });
    return response.data;
  } catch (error) {
    if (error.response?.status === 401) {
      console.warn("Користувач не автентифікований");
      return null;
    }
    console.error("Помилка перевірки авторизації:", error);
    return null;
  }
};
