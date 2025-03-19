import { Navigate, Outlet } from "react-router-dom";

import { AccountMachineContext } from "../contexts/accountContext";

export default function Anonymous() {
  const state = AccountMachineContext.useSelector((state) => state.value);

  const isAuthenticated = state === "authenticated";

  return isAuthenticated ? <Navigate to="/" replace /> : <Outlet />;
}
