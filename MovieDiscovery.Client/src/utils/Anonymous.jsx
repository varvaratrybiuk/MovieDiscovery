import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "../hooks/useAuth";

export default function Anonymous() {
  const isAuthenticated = useAuth();

  if (isAuthenticated === null) return <p>Loading...</p>;

  return isAuthenticated ? <Navigate to="/" replace /> : <Outlet />;
}
