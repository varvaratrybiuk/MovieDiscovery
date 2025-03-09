import { useEffect, useState } from "react";
import { checkAuth } from "../services/accountService";

export const useAuth = () => {
  const [isAuthenticated, setIsAuthenticated] = useState(null);

  useEffect(() => {
    const fetchAuthStatus = async () => {
      const result = await checkAuth();
      setIsAuthenticated(result !== null);
    };

    fetchAuthStatus();
  }, []);

  return isAuthenticated;
};
