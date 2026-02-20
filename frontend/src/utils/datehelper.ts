export function formatDate(isoString: string): string {
  const date = new Date(isoString);

  return new Intl.DateTimeFormat("en-US", {
    month: "short",   // "Jan", "Feb", etc.
    day: "numeric",   // 1, 2, 31
    year: "numeric"   // 2026
  }).format(date);
  
}