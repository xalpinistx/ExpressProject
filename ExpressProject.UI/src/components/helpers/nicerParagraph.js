export default function niceParagrapsh(paragraph) {
  const result = paragraph
    .split(" ")
    .slice(0, 22)
    .join(" ")
    .trim()
    .replace(/[,.-_;:]*$/, "")
    .concat("...");
  return result;
}
