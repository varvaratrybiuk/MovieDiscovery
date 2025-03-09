import { Navigate, Outlet } from "react-router-dom";

import { AccountMachineContext } from "../contexts/accountContext";

export default function ProtectedRoute() {
  const state = AccountMachineContext.useSelector((state) => state.value);

  const isAuthenticated = state === "authenticated";

  return isAuthenticated ? <Outlet /> : <Navigate to="/login" replace />;
}
