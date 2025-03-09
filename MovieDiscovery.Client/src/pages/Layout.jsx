import { Outlet } from "react-router-dom";

import { useAuth } from "../hooks/useAuth";

import NavBar from "../components/navBar/NavBar";

import { PATH_OPTIONS } from "../constants/constants";

export default function Layout() {
  const isAuthenticated = useAuth();

  const filteredOptions = PATH_OPTIONS.filter(
    (option) =>
      option.requiresAuth === null || option.requiresAuth === isAuthenticated
  );

  return (
    <>
      <NavBar options={filteredOptions} />
      <Outlet />
    </>
  );
}
