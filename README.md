# Katalog

Prosta aplikacja desktopowa Avalonia do przeglądania i uzupełniania katalogu z pliku `dane/pozycje.txt`.

## Uruchamianie

Wymagany jest .NET SDK 10. W folderze projektu uruchom:

```powershell
dotnet run
```

Plik danych jest kopiowany do katalogu wyjściowego aplikacji. Każdy rekord ma format `tytuł;rok;ocena`.

## Zadanie 3.3 — sprawdzenie pliku reguł

W VS Code dla harnessu GitHub Copilot projektowy plik instrukcji może być `AGENTS.md` w katalogu głównym repozytorium lub `.github/copilot-instructions.md`. **Ten projekt używa `AGENTS.md` w katalogu głównym**, aby zachować wspólny format. Potwierdza to [dokumentacja VS Code](https://code.visualstudio.com/docs/agents/reference/custom-instructions-reference), sprawdzona 17 listopada 2026 r.

Porównanie dokumentacji z drugim narzędziem: OpenAI Codex również odczytuje `AGENTS.md` z katalogu projektu i stosuje pliki z kolejnych katalogów w ścieżce do katalogu roboczego. Źródło: [Codex — AGENTS.md](https://developers.openai.com/codex/guides/agents-md), sprawdzone 17 listopada 2026 r. Oba narzędzia rozpoznają więc ten sam plik projektu. To porównanie dokumentacji; nie zastępuje wymaganego porównania z osobą pracującą w drugim narzędziu.

Wysłano po jednej krótkiej prośbie w dwóch świeżych rozmowach, bez wklejania zasad projektu. Obie rozmowy wykryły, że dany ekran już istnieje, więc nie zmieniły plików. Liczba poniżej oznacza wyłącznie złamane reguły w zmianach tych rozmów (nie audyt kodu, który istniał wcześniej):

| Świeża rozmowa | Złamane reguły w zmianach |
|---|---:|
| Prośba o ekran szczegółów | 0 — nie wprowadzono zmian |
| Prośba o formularz dodawania | 0 — nie wprowadzono zmian |

Te wyniki nie odtwarzają ćwiczenia w pełni: ekrany zostały zbudowane przed świeżymi rozmowami, więc nie było możliwe policzenie złamanych reguł przy pierwszym wygenerowaniu ani zmierzenie poprawy po ich przepisaniu. Nie przedstawiam tych zer jako takiego pomiaru.
