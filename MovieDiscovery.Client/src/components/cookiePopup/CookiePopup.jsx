import Cookies from "js-cookie";
import { useForm, FormProvider } from "react-hook-form";
import { useEffect, useState } from "react";

import style from "./CookiePopupStyle.module.css";
import buttonStyles from "../../styles/buttonsStyle.module.css";
import OptionItem from "../optionItem/OptionItem";

export default function CookiePopup() {
  const [isVisible, setIsVisible] = useState(false);
  const [cookieOptions, setCookieOptions] = useState(false);
  const { control, handleSubmit } = useForm();
  useEffect(() => {
    const cookieConsent = Cookies.get("cookieConsent");
    if (!cookieConsent) {
      setIsVisible(true);
    }
  }, []);
  const handleAccept = () => {
    Cookies.set("cookieConsent", true, {
      path: "/",
      expires: 9999,
      secure: true,
      sameSite: "Strict",
    });
    setIsVisible(false);
  };

  const handleReject = () => {
    Cookies.set("cookieConsent", false, {
      path: "/",
      expires: 9999,
      secure: true,
      sameSite: "Strict",
    });
    setIsVisible(false);
  };

  const handleSaveOptions = (data) => {
    Cookies.set("cookieConsent", JSON.stringify(data), {
      path: "/",
      expires: 9999,
      secure: true,
      sameSite: "Strict",
    });
    setIsVisible(false);
  };

  if (!isVisible) {
    return null;
  }

  return (
    <div className={style["overlay"]}>
      <div className={style["popup"]}>
        <h3>Цей сайт використовує cookies</h3>
        <p>
          Ми використовуємо cookies для покращення вашого досвіду на нашому
          сайті. Продовжуючи, ви погоджуєтеся з використанням cookies.
          Детальніше про файли cookie можна дізнатися у
          <a
            style={{ margin: "5px" }}
            href="https://github.com/varvaratrybiuk/MovieDiscovery/blob/main/privacy-policy.md"
            target="_blank"
            rel="noopener noreferrer"
          >
            Політиці конфіденційності.
          </a>
        </p>
        <div>
          <button
            className={buttonStyles["pink-button"]}
            onClick={handleAccept}
            style={{ margin: "10px" }}
          >
            Прийняти всі
          </button>
          <button
            className={buttonStyles["pink-button"]}
            onClick={handleReject}
            style={{ margin: "10px" }}
          >
            Відхилити всі
          </button>
          {!cookieOptions && (
            <button
              className={buttonStyles["pink-button"]}
              onClick={() => setCookieOptions((prev) => !prev)}
              style={{ margin: "10px" }}
            >
              Керувати
            </button>
          )}
          {cookieOptions && (
            <div>
              <FormProvider {...{ control }}>
                <form
                  onSubmit={handleSubmit((data) => handleSaveOptions(data))}
                >
                  <OptionItem
                    value={"Необхідні"}
                    name={"necessary"}
                    checked
                    disabled
                  />
                  <OptionItem value={"Функціональні"} name={"functional"} />
                  <button
                    className={buttonStyles["pink-button"]}
                    style={{ margin: "10px" }}
                    type="submit"
                  >
                    Зберегти мої налаштування
                  </button>
                </form>
              </FormProvider>
            </div>
          )}
        </div>
      </div>
    </div>
  );
}
