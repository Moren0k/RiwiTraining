export function courseStatusLabel(status: number): string {
  switch (status) {
    case 0:
      return "Draft";
    case 1:
      return "Published";
    default:
      return "Unknown";
  }
}