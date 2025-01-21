# NATS Bus

A messaging bus library that provides the following guarantees on top of NATS JetStream service:

1. Exactly-once message processing
2. Ordered message processing per corelation ID as defined by the user
3. Scalable competing consumers against parallel messages
