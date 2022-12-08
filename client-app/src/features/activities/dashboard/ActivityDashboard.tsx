import React from "react";
import { Grid } from "semantic-ui-react";
import { Activity } from "../../../app/models/Activity";
import ActivityList from "./ActivityList";
import ActivityDetails from "../details/ActivityDetails";
import ActivityForm from "../form/ActivityForm";

// Creating an interface in the component for activities.
interface Props {
  activities: Activity[];
  // This is important here... we specified in App.tsx (in the state variable this was initialized in) that this needs to either be Activity or undefined, so we need to include that here.
  selectedActivity: Activity | undefined;
  // setting the selectActivity input to id of type string, and the return value of void for this one
  selectActivity: (id: string) => void;
  cancelSelectActivity: () => void;
  editMode: boolean;
  openForm: (id: string) => void;
  closeForm: () => void;
  createOrEdit: (actiivty: Activity) => void;
  deleteActivity: (id: string) => void;
}

// We are destructuring the activities from Props here so we dont have to keep adding props.____ every time we want to use props.
export default function ActivityDashboard({
  activities,
  selectedActivity,
  deleteActivity,
  selectActivity,
  cancelSelectActivity,
  editMode,
  openForm,
  closeForm,
  createOrEdit
}: Props) {
  return (
    <Grid>
      <Grid.Column width="10">
        <ActivityList
          activities={activities}
          selectActivity={selectActivity}
          deleteActivity={deleteActivity}
        ></ActivityList>
      </Grid.Column>
      <Grid.Column width="6">
        {selectedActivity && !editMode && (
          <ActivityDetails
            activity={selectedActivity}
            cancelSelectActivity={cancelSelectActivity}
            openForm={openForm}
          ></ActivityDetails>
        )}
        {editMode && (
          <ActivityForm
            closeForm={closeForm}
            activity={selectedActivity}
            createOrEdit={createOrEdit}
          ></ActivityForm>
        )}
      </Grid.Column>
    </Grid>
  );
}
