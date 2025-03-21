import { Outlet } from "react-router-dom";
import { useEffect } from "react";

import NavBar from "../components/navBar/NavBar";

import { AccountMachineContext } from "../contexts/accountContext";

import { PATH_OPTIONS } from "../constants/constants";

export default function Layout() {
  const state = AccountMachineContext.useSelector((state) => state.value);
  const actor = AccountMachineContext.useActorRef();

  const isAuthenticated = state === "authenticated";

  const filteredOptions = PATH_OPTIONS.filter(
    (option) =>
      option.requiresAuth === null || option.requiresAuth === isAuthenticated
  );

  useEffect(() => {
    if (state === "error") {
      actor.send({
        type: "RETRY",
      });
    }
  }, [state, actor]);

  return (
    <>
      <NavBar options={filteredOptions} />
      <Outlet />
    </>
  );
}
