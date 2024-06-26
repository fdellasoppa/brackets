//import { onChange } from "react-input";

function CultureSelection() {
    const cultures: string[] = ["en-US", "es-AR"];
    const names: string[] = ["English", "Spanish"];

    const toLabel = (index: number): string => {
        return names[index];
    };

    const handleChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
        //onChange(cultures[e.target.selectedIndex]);
        cultures[e.target.selectedIndex]; // TODO: Change with above line
    };

  return (
      <p>
          <label>
              <b>Select your language:</b>
              <select value="0" onChange={handleChange}>
                  {cultures.map((value, index) => (
                      <option value={value} key={value}>
                          {toLabel(index)}
                      </option>
                  ))}
              </select>
          </label>
      </p >
  );
}

export default CultureSelection;