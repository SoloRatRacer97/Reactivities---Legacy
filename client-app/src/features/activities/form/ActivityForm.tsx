import { Button, Form, Segment } from "semantic-ui-react";

import React, { ChangeEvent, useState } from "react";
import { Activity } from "../../../app/models/Activity";

interface Props {
  // Again with defining activity as possibly undefined... I forget why
  activity: Activity | undefined;
  closeForm: () => void;
  createOrEdit: (activity: Activity) => void
}

export default function ActivityForm({
  activity: selectedActivity,
  closeForm,
  createOrEdit
}: Props) {
  const initialState = selectedActivity ?? {
    id: "",
    title: "",
    catagory: "",
    description: "",
    date: "",
    city: "",
    venue: "",
  };

  const [activity, setActivity] = useState(initialState);

  function handleSubmit() {
      createOrEdit(activity);
  }

  // We need to handle this change event or else React wont let us update the field.
  // I dont think I've seen this way of updating the field and letting React know what the value is. This is similar to setting the value in the jsx below to the value that React has for that element, but this seems more clever....
  function handleInputchange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
    const { name, value } = event.target;
    // Propery called name is set to value
    setActivity({ ...activity, [name]: value });
  }

  return (
    <Segment clearing>
      <Form onSubmit={handleSubmit} autoComplete="off">
        <Form.Input
          placeholder="Title"
          value={activity.title}
          name="title"
          onChange={handleInputchange}
        ></Form.Input>
        <Form.TextArea
          placeholder="Description"
          value={activity.description}
          name="description"
          onChange={handleInputchange}
        ></Form.TextArea>
        <Form.Input
          placeholder="Category"
          value={activity.catagory}
          name="catagory"
          onChange={handleInputchange}
        ></Form.Input>
        <Form.Input
          placeholder="Date"
          value={activity.date}
          name="date"
          onChange={handleInputchange}
        ></Form.Input>
        <Form.Input
          placeholder="City"
          value={activity.city}
          name="city"
          onChange={handleInputchange}
        ></Form.Input>
        <Form.Input
          placeholder="Venue"
          value={activity.venue}
          name="venue"
          onChange={handleInputchange}
        ></Form.Input>
        <Button
          floated="right"
          positive
          type="submit"
          content="Submit"
        ></Button>
        <Button
          onClick={closeForm}
          floated="right"
          type="button"
          content="Cancel"
        ></Button>
      </Form>
    </Segment>
  );
}
