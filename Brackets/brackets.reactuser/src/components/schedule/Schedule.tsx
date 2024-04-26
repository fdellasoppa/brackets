import { Client } from "../../client/bracketsApi";
import { useQuery } from "@tanstack/react-query";


function Schedule() {
    const queryKey = 'matches';

    // Queries
    const query = useQuery({ queryKey: [queryKey], queryFn: new Client().matches });

    return (
        <p>
            <ul>{
                query.data?.map((match) => <li key={match.id?.id}>{match.localTeam?.name}</li>)
            }</ul>
        </p >
  );
}

export default Schedule;