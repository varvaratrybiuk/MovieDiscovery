import { useRouteError } from "react-router-dom";

import UnexpectedError from "../../components/error/UnexpectedError";

export default function ErrorPage() {
  const error = useRouteError();
  let errorMessage = "";

  if (error instanceof Error) {
    errorMessage = error?.message;
  } else if (error?.status) {
    errorMessage = `Помилка ${error.status}: ${
      error.statusText || "Невідома помилка"
    }`;
  }
  return (
    <div>
      <UnexpectedError errorText={errorMessage} />
    </div>
  );
}
