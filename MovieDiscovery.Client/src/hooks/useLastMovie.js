import { useState, useEffect } from "react";
import Cookies from "js-cookie";

export function useLastMovie(lastMovieTitle) {
  const res = Cookies.get("cookieConsent");

  let consent = {};
  try {
    consent = JSON.parse(res);
  } catch {}

  useEffect(() => {
    if (
      lastMovieTitle !== "" &&
      lastMovieTitle &&
      (res === "true" || consent.functional == true)
    ) {
      Cookies.set("last-movie", JSON.stringify({ title: lastMovieTitle }), {
        path: "/",
        expires: 1,
        secure: true,
        sameSite: "Strict",
      });
    }
  }, [lastMovieTitle]);
}
