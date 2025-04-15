FROM mongo:8
CMD openssl rand -base64 756 /data/keyfile
CMD chmod 400 /data/keyfile
CMD chown 999:999 /data/keyfile
ENTRYPOINT ["docker-entrypoint.sh"]
