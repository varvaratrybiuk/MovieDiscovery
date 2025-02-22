
export const filterOutFalse = (array) => {
  return array
    .map((value, index) => (value === true ? index : null))
    .filter((index) => index !== null);
};