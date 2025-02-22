import { lazy } from "react";
import {
  createBrowserRouter,
  RouterProvider,
  Navigate,
} from "react-router-dom";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

import Layout from "./pages/Layout";
const Home = lazy(() => import("./pages/home/Home"));
const AddNewMovie = lazy(() => import("./pages/addNewMovie/AddNewMovie"));
const ErrorPage = lazy(() => import("./pages/error/ErrorPage"));

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
          path: "add",
          element: <AddNewMovie />,
        },
      ],
    },
    {
      path: "*",
      element: <Navigate to="/" replace />,
    },
  ]);

  return (
    <QueryClientProvider client={queryClient}>
      <RouterProvider router={router} />
    </QueryClientProvider>
  );
}

export default App;
