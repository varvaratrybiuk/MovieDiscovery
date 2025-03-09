import { lazy } from "react";
import {
  createBrowserRouter,
  RouterProvider,
  Navigate,
} from "react-router-dom";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

import Layout from "./pages/Layout";
import ProtectedRoute from "./utils/ProtectedRoute";
import Anonymous from "./utils/Anonymous";
const Home = lazy(() => import("./pages/home/Home"));
const AddNewMovie = lazy(() => import("./pages/addNewMovie/AddNewMovie"));
const ErrorPage = lazy(() => import("./pages/error/ErrorPage"));
const LoginPage = lazy(() => import("./pages/login/LoginPage"));
const RegisterPage = lazy(() => import("./pages/register/RegisterPage"));
const ProfilePage = lazy(() => import("./pages/profile/ProfilePage"));

import { AccountProvider } from "./contexts/accountContext";

import "./App.css";

const queryClient = new QueryClient();

function App() {
  const router = createBrowserRouter([
    {
      path: "/",
      element: <Layout />,
      errorElement: <ErrorPage />,
      children: [
        {
          index: true,
          element: <Home />,
        },
        {
          element: <ProtectedRoute />,
          children: [
            {
              path: "add",
              element: <AddNewMovie />,
            },
            {
              path: "profile",
              element: <ProfilePage />,
            },
          ],
        },
        {
          element: <Anonymous />,
          children: [
            {
              path: "login",
              element: <LoginPage />,
            },
            {
              path: "register",
              element: <RegisterPage />,
            },
          ],
        },
      ],
    },
    {
      path: "*",
      element: <Navigate to="/" replace />,
    },
  ]);

  return (
    <AccountProvider>
      <QueryClientProvider client={queryClient}>
        <RouterProvider router={router} />
      </QueryClientProvider>
    </AccountProvider>
  );
}

export default App;
