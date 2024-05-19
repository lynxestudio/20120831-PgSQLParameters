CREATE OR REPLACE FUNCTION createrefnum(id numeric)
  RETURNS character varying AS
 '
DECLARE
refnum    varchar;
rndnum    numeric;
BEGIN
rndnum := CAST((random() * 1000) + DATE_PART(''year'',CURRENT_DATE) AS int2);
refnum := cast(rndnum as varchar) || cast(id as varchar);
 RETURN refnum;
END;'
  LANGUAGE plpgsql VOLATILE