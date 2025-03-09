import api from "./api";

export const login = async (loginData) => {
  try {
    const response = await api.post("/account/login", loginData, {
      withCredentials: true,
    });
    return response.data;
  } catch (error) {
    //console.error("Помилка при вході користувача:", error);
    throw error;
  }
};

export const register = async (registerData) => {
  try {
    const response = await api.post("/account/register", registerData);
    return response.data;
  } catch (error) {
    //console.error("Помилка при додаванні користувача:", error);
    throw error;
  }
};

export const logout = async () => {
  try {
    await api.post("/account/logout", {}, { withCredentials: true });
  } catch (error) {
   // console.error("Помилка при виході:", error);
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
    //console.error("Помилка перевірки авторизації:", error);
    return null;
  }
};

export const updateUser = async (userData) => {
  try {
    const response = await api.put("/account/update", userData, {
      withCredentials: true,
    });
    return response.data;
  } catch (error) {
   // console.error("Помилка при оновленні:", error);
    throw error;
  }
};

export const deleteUser = async () => {
  try {
    await api.delete("/account/delete", {
      withCredentials: true,
    });
  } catch (error) {
   // console.error("Помилка при видаленні:", error);
    throw error;
  }
};

export const getAuthUserInfo = async () => {
  try {
    const response = await api.get("/account/auth-user", {
      withCredentials: true,
    });
    return response.data;
  } catch (error) {
    //console.error("Помилка при отриманні даних користувача:", error);
    throw error;
  }
};
