import { createActorContext } from "@xstate/react";

import { accountMachine } from "../machines/account";

export const AccountMachineContext = createActorContext(accountMachine);

export const AccountProvider = ({ children }) => {
  return (
    <AccountMachineContext.Provider>{children}</AccountMachineContext.Provider>
  );
};
