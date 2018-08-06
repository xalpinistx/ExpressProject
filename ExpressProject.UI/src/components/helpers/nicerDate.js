export default date => {
  let options = {
    year: "numeric",
    month: "short",
    day: "numeric",
  };

  date.toLocaleString("en-us", options);
  //const newDate = date.replace("^[/(d{4})-(d{2})-(d{2})/]", "");
  return date;
};
