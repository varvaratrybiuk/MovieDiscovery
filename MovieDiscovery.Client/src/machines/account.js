import { setup, fromPromise, assign } from "xstate";
import {
  deleteUser,
  login,
  register,
  logout,
  updateUser,
  checkAuth,
} from "../services/accountService";

export const accountMachine = setup({
  actors: {
    checkingAuth: fromPromise(async () => {
      const user = await checkAuth();
      if (user) {
        return { user };
      } else {
        throw new Error("Користувач не авторизований");
      }
    }),
    loginAction: fromPromise(async ({ input }) => {
      console.log("Логін користувача");
      const response = await login(input.user);
      return { message: response.message };
    }),
    registerAction: fromPromise(async ({ input }) => {
      console.log("Реєстрація користувача");
      await register(input.user);
      return { message: "Користувач успішно зареєстрований" };
    }),
    logoutAction: fromPromise(async () => {
      console.log("Вихід з акаунту");
      const response = await logout();
      return { message: response.message };
    }),
    updateProfileAction: fromPromise(async ({ input }) => {
      console.log("Оновлення профілю");
      await updateUser(input.profileData);
      return { message: "Оновлення успішне" };
    }),
    deleteUserAction: fromPromise(async () => {
      console.log("Видалення акаунту");
      await deleteUser();
      return { message: "Видалення акаунту успішне" };
    }),
  },
}).createMachine({
  /** @xstate-layout N4IgpgJg5mDOIC5QEMDGqD2BXAdgFwDpUALMVAawEscoBBLPYgYggxzAOoDcNyOSy5eowDaABgC6iUAAcMsSnkptpIAB6IAzAFYAjAQBsADgDs2g9oAsBy9oBMd3doA0IAJ6JdugJyaCm710TEzFLTTsjTV1LAF8Y1zRMXEIBCmo6BmYwACdsjGyCGQAbZDwAM3yAWyJSCmFicSkkEDkFJRVmjQQdfWMzC2tbBydXDwQQv10DAxMgp0tLO3s4hPRsfE4IIrAmABkAeQBxAEkAOUbVVsVlHFUu6bECazsDMQtzN6jRxGM-KynvHZvEZdGInJoViBEutCJQtjsAEoAUROAGUACpIhEXZpXdq3To-V5PAwvN7aD4GL7uTxiIEECmRcygmbhWLxKFrZIEIoYKBQdLHHAsNgcbi8Di8gU4HGyeTXDqgLqgkx+MSaEwzOyzOmaUnfcaaggmQImSygzQLAImSHQ7lS6VQIVMHJ5ArFUoVbLVKXUWUteX4u601UEdWakza0F2PV2A02IxhsTJoxicx6KJ2W1cjbZMAC2B4HLpEXsTg4Hh8Ah5gtF7L+vE3YMIFVqjVanUx-U0ltiIwGfzTSPBUzq9mrJK5-OUQvFmgu3L5QolcpVavT2f1ySXQNNwm90PhjvR2MG7zeSxhqZmvXePuWIxZjl2jbITJgfCUVClSB7I77ABVdEG13RV1E8C0CF0UxIzpGNyQNOwFn8ZNQXVJZvHsDVs0nQg30YD8lG-IsICYACAAUABFaExAB9ciEX2AAxY5diREC2j3JVPEsMRvEMJYgWsEI9CpA0jFsAggSCPQpgMbx5N0HCYQIfDSE-Yjf0opE2Lo2gAGF9MA05gO3XFQIJbiW14-jSXsC8ZjTKZNHEi8CHPIIwiGTC9GU+0+UdfYGFLMUKwlHk+WwPAOIVSzwO6PRDFMdNBnsRwXB7PVLwsZMFOsIwL20CFnxzQgHXSIK8AXN1l09NcpSimKg33Hokv6KwbDSkYexBFDULMOw+wMXQAj8jYsBkCBSnSci8jKShthC8tKw4CapqLWaMHm7Ymq4+LokG41tDg7RIx0ZMMrGE1E20U0pksVUxBMUwxsINbppoTbtp2V0lw9VdvQId6NrmhawF2sDlQUx4wQiMIXnkxwDRNXpjqemMzE0KJXoICAwG2JQaFoUqlvFKs8YJsBidwiG4uVc0-DCYJZn7JDwQNLxH38U0QnhyJohximwEJugSd+90Vy9aohaLamYVp5sfGJWGJPCaZAV0Dm5IZe8AkfC8ogMHHxaYZF0QRABNBX90G6woIut4Y0WVUjANewTEMNGJMWRxNEfOIORwDA8fgZoXzwHdOMhxAAFoDANGPtHc88U9T1PionFTUioInMkj2Lm0WN2kKeJZ7wedVdCfTPuThbZ8+aqz7AHF4yTJAI+JMeM3NE1VmcCPijZK3CIv5QU4sbaOEBBAdMLBLzjGiKx42JNmzQe61TqHmup1rOcoAbvauhNJO0eiTVHcfSwOeTFvtAkp7+ysM1t85Ee1MIr8fwgQ+p6rv33KCQcLeaCYkeppgZEOc6lhTTDRxuVGglVf500QGYKCGpbqhGOpGXirseygn0HeW+oICqpktOON+KlgYzVBvXcyUcUEtmGvoPuqZnovAKhqZGBVDBmHRsNcIbNBb42FukOWyRkGK2GnYY0pgmSzDutffB90GRYwWLfVUSFX7hwIOLSRNsgizzMDZTud5IzxjQX7XwPhnp+2iOyOIQA */
  id: "account",
  initial: "checkingAuth",
  context: {
    errorMessage: "",
    message: "",
  },
  states: {
    checkingAuth: {
      invoke: {
        id: "checkAuth",
        src: "checkingAuth",
        onDone: {
          target: "authenticated",
          actions: assign({
            user: ({ event }) => event.output.user,
          }),
        },
        onError: {
          target: "idle",
        },
      },
    },
    idle: {
      on: {
        LOGIN: "loggingIn",
        REGISTER: "registering",
      },
    },
    loggingIn: {
      invoke: {
        id: "login",
        src: "loginAction",
        input: ({ event }) => ({
          user: { username: event.username, password: event.password },
        }),
        onDone: {
          target: "authenticated",
          actions: assign({
            errorMessage: () => "",
          }),
        },
        onError: {
          target: "error",
          actions: assign({
            errorMessage: ({ event }) =>
              event.error?.response?.data?.detail ||
              event.error?.response?.data,
          }),
        },
      },
    },
    registering: {
      invoke: {
        id: "register",
        src: "registerAction",
        input: ({ event }) => ({
          user: event.user,
        }),
        onDone: {
          target: "idle",
          actions: assign({
            errorMessage: () => "",
          }),
        },
        onError: {
          target: "error",
          actions: assign({
            errorMessage: ({ event }) => event.error?.response?.data?.message,
          }),
        },
      },
    },
    authenticated: {
      on: {
        LOGOUT: "loggingOut",
        UPDATE_PROFILE: "updatingProfile",
        DELETE_ACCOUNT: "deletingAccount",
      },
    },
    loggingOut: {
      invoke: {
        id: "logout",
        src: "logoutAction",
        onDone: {
          target: "checkingAuth",
          actions: assign({
            errorMessage: () => "",
          }),
        },
        onError: {
          target: "error",
          actions: assign({
            errorMessage: ({ event }) => event.error?.response?.data?.message,
          }),
        },
      },
    },
    updatingProfile: {
      invoke: {
        id: "updateProfile",
        src: "updateProfileAction",
        input: ({ event }) => ({ profileData: event.profileData }),
        onDone: {
          target: "authenticated",
          actions: assign({
            errorMessage: () => "",
          }),
        },
        onError: {
          target: "error",
          actions: assign({
            errorMessage: ({ event }) => event.error?.response?.data?.message,
          }),
        },
      },
    },
    deletingAccount: {
      invoke: {
        id: "deleteAccount",
        src: "deleteUserAction",
        onDone: {
          target: "checkingAuth",
        },
        onError: {
          target: "error",
          actions: assign({
            errorMessage: ({ event }) => event.error?.response?.data?.message,
          }),
        },
      },
    },
    error: {
      on: {
        RETRY: {
          target: "checkingAuth",
        },
      },
    },
  },
});
